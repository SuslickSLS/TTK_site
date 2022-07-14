//const { css } = require("jquery");

let game ={

    ctx: null,
    GameOver: false,

    widthCanvas:1200,
    heigthCanvas:650,

    ball:null,
    platform:null,
    blocks:[],

    rows:4,
    cols:5,

    score:0,

    sprites:{
        BG:null,
        Ball:null,
        Platform:null,
        Block:null
    },
   

    init:function() {
        this.ctx = document.getElementById("mycanvas").getContext("2d");
        this.setEvents();
    },

    setEvents(){
        window.addEventListener("keydown", e =>{      
            if(e.key == "ArrowLeft" || e.key == "ArrowRight")
            {
               this.platform.start(e.key);
            }
            else if(e.key == " ")
            {
                this.platform.fire();
                
            }
        });

        window.addEventListener("keyup",e=>{

            this.platform.stop();          
        })
    },

    preload:function (callback) {
        let loaded = 0;
        let required = Object.keys(this.sprites).length;


        let ImageLoad = () =>{
            ++loaded;
            if(loaded >= required)
            {
                callback();
               
            }
        };


        for(let i in this.sprites){
            this.sprites[i] = new Image();
            this.sprites[i].src = "C:/Users/Suslick/Desktop/New/TTK/TTK/wwwroot/Img/Game/" + i + ".png";
            this.sprites[i].addEventListener("load", ImageLoad);
        }

    },


    
    create:function() {
        for(let row=0; row < this.rows;row++)
        {
            for(let col=0; col < this.cols;col++)
            {
                this.blocks.push({
                    active:true,
                    width:200,
                    heigth:  50,
                    x:202 * col + 100,
                    y:51 * row + 80
                });
            }
        }
    },
    
    
    update:function() {
        
        this.Coliderblock();
        this.ColiderPlatform();
        this.platform.ColiderWorldPlatform();
        this.ball.ColiderWorld();
       

        this.platform.move();
        this.ball.move();

    },
    AddScore(){
        ++this.score;

        if(this.score >= this.blocks.length)
        {
            this.GameOver_END("WIN!!!!"); 
        }
    },
    Coliderblock(){
        for(let block of this.blocks)
        {
            if(this.ball.colider(block) && block.active)
            {
               this.ball.BlockBums(block);
               this.AddScore();
            }
        }
    },

    ColiderPlatform(){
        if(this.ball.colider(this.platform))
        {
            this.ball.PlatformBums(this.platform);
        }
    },

    run:function () {
        if(!this.GameOver)
        {
            window.requestAnimationFrame(() =>{

                this.update();
                this.render();
                this.run();
            });
         }
    },

    render:function() {
        this.ctx.clearRect(0,0,this.widthCanvas,this.heigthCanvas);

        this.ctx.drawImage(this.sprites.BG, 0 ,0);
        this.ctx.drawImage(this.sprites.Ball, 0, 0, this.ball.width, this.ball.heigth, this.ball.x, this.ball.y, this.ball.width, this.ball.heigth);
        this.ctx.drawImage(this.sprites.Platform, this.platform.x, this.platform.y);

        this.rederblock();
    },

    rederblock(){
        for(let block of this.blocks)
        {
            if(block.active)
            {
                this.ctx.drawImage(this.sprites.Block,block.x,block.y);
            }
        }
    },

    start:function() {

       this.init();
       this.preload(()=>{
           this.create();
           this.run();
       });

      
        
    },

    random(min,max){
        return Math.floor(Math.random() * (max- min + 1) + min);
    },

    
    GameOver_END(over){
        this.GameOver = true;
        alert(over);
        window.location.reload(); 
    }
};

game.ball ={
    x:590,
    y:520,
    width:30,
    heigth:30,
    speed:5,
    a_speed_to_y:0,
    a_speed_to_x:0,

    start(){
        this.a_speed_to_y = -this.speed;
        this.a_speed_to_x = game.random(-this.speed, this.speed);
    },

    move(){
        if(this.a_speed_to_y)
        {
            
            this.y += this.a_speed_to_y; 
        }

        if(this.a_speed_to_x)
        {
            
            this.x += this.a_speed_to_x; 
            
        }
    }, 

    colider(element) {
        let x = this.a_speed_to_x + this.x;
        let y = this.a_speed_to_y + this.y;

        if(x + this.width > element.x &&
           x < element.width + element.x &&
           y + this.heigth > element.y &&
           y < element.heigth + element.y)
           {
                return true;
           }
           return false;
    },

    BlockBums(block){
        this.a_speed_to_y *= -1;
        block.active = false;
    },
    ColiderWorld(){
        let x = this.a_speed_to_x + this.x;
        let y = this.a_speed_to_y + this.y;

        let ballLeft  = x;
        let ballRigth = x + this.width;
        let ballTop = y;
        let ballBottom = y + this.heigth;

        let worldleft = 0;
        let worldright = game.widthCanvas;
        let worldTop = 0;
        let worldBottom = game.heigthCanvas

        if(ballLeft < worldleft)
        {
            this.x =0;
            this.a_speed_to_x = this.speed
            
        }else if(ballRigth > worldright)
        {
            this.x = worldright - this.width;
            this.a_speed_to_x = -this.speed

        }else if(ballTop < worldTop)
        {
            this.y =0;
            this.a_speed_to_y = this.speed
        }else if (ballBottom > worldBottom)
        {
            game.GameOver_END("GameOver"); 
        }
    },

    PlatformBums(platform) {
        if(platform.a_Speed)
        {
            this.x += platform.a_Speed;

        }
       if(this.a_speed_to_y > 0)
       {
        this.a_speed_to_y = -this.speed;
        let touchX = this.x + this.width /2;
      
        this.a_speed_to_x = this.speed * platform.getTouchToX(touchX);
       }
        
    },

}

game.platform ={
    x: 500,
    y:550,
    width:200,
    heigth:  50,
    speed:10,
    a_Speed:0,
    ball:game.ball,

    start(direction){
        if(direction == "ArrowLeft" )
            {
                this.a_Speed = -this.speed;

            }else if(direction == "ArrowRight")
            {
                this.a_Speed = this.speed;
            }
    },

    fire(){
        if(this.ball)
        {
            this.ball.start();
            this.ball = null;
        }
    },

    stop(){
        this.a_Speed = 0;
    },

    move () {
        if(this.a_Speed)
        {
            this.x += this.a_Speed; 
            
            if(this.ball)
            {
                this.ball.x += this.a_Speed; 
                
            }
        }
    },

    ColiderWorldPlatform(){
        let x = this.a_Speed + this.x;
       

        let PlatformLeft  =x;
        let PlatformRigth =x + this.width;

        if(PlatformLeft < 0 || PlatformRigth > game.widthCanvas)
        {
            this.stop();
            
        }
    },
    getTouchToX(touchX) {
        
        let diff = (this.x + this.width) - touchX;
        let offset = this.width - diff;

        let result = 2 * offset / this.width;
        return result - 1;
    }
    
}


window.addEventListener("load", ()=>{

    game.start();
});