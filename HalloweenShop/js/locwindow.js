/* const button = document.querySelector('#Button');
const form = document.querySelector('#blablabla');
const buttonExist = document.querySelector('.btn');
const divExist = document.querySelector('.popup');
const popup = document.querySelector('.popup');

/*если происходить нажатие, то к селектору добавляются селекторы с названиями в скобках

button.addEventListener('click', () => {
  form.classList.add('open');
  popup.classList.add('popup_open');
});

buttonExist.addEventListener('click', () => {
  form.classList.remove('open');
  popup.classList.remove('popup_open');
});
 */
 
 // функция вызова окна
function show_popap(id_popap) {
  var id = "#" + id_popap;
  var elem = document.getElementById(id_popap).getElementsByClassName('popap')[0];

var date = new Date(); //текущая дата
var h =   date.getHours(); /* это текущий час*/

if(h >= 6 && h <= 20 ) {      
      elem.style.background = "#ffe375";
}
if(h >= 21 || h <= 5) {   
	   elem.style.background = "#00001a";
	   elem.style.color = "white";
}	 
 
  $(id).addClass('active');
 } 


// функция закрытия окна 
$(".close_popap").click( function(){
  $(".overlay").removeClass("active");
});

