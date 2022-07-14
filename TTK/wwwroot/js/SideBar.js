let btn = document.querySelector("#btn");
let sidebar = document.querySelector(".sidebar");

btn.onclick = function(){
 sidebar.classList.toggle("active");
}

//Client
let btn_client = document.querySelectorAll(".btn_table");
let menu = document.querySelector(".Left_Menu");
let btn_close = document.querySelector(".Menu_close");

for (btn of btn_client) {
	btn.addEventListener("click", e => btn_client_Click(e));
}

function btn_client_Click(){
    menu.classList.toggle("active");
}

btn_close.onclick = function(){
    menu.classList.remove("active");
}


window.addEventListener("keydown",e=>{

   if(e.key === "Enter")
   {
       myFunction();
   }
});

function myFunction() {
    // Объявить переменные
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("search");
    filter = input.value.toUpperCase();
    table = document.querySelector(".table_client");
    tr = table.getElementsByTagName("tr");
  
    // Перебирайте все строки таблицы и скрывайте тех, кто не соответствует поисковому запросу
    for (i = 0; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td")[0];
      if (td) {
        txtValue = td.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          tr[i].style.display = "";
        } else {
          tr[i].style.display = "none";
        }
      }
    }
}