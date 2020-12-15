window.onload = function(){
if(window.XMLHttpRequest){
xmlhttp = new XMLHttpRequest();
}
else {
xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
}

xmlhttp.open("GET","xml/footerInfo.xml", false);
xmlhttp.send();
xmlDoc = xmlhttp.responseXML;
var x=xmlDoc.getElementsByTagName("STUDENT");



document.getElementById('footerinf').innerHTML = /* "<table border='1' width=60%' cellpadding='5'>"+
"<tr><th>ФИО</th><th>Факультет</th><th>Специальность</th><th>Группа</th><th>Год</th></tr><tr><td>"+x[0].getElementsByTagName("NAME")[0].childNodes[0].nodeValue+"</td>"+
"<td>" + x[0].getElementsByTagName("FACULTY")[0].childNodes[0].nodeValue + "</td>"+

"<td>" + x[0].getElementsByTagName("SPECIALITY")[0].childNodes[0].nodeValue + "</td>"+
"<td>" + x[0].getElementsByTagName("GROUP")[0].childNodes[0].nodeValue + "</td>"+

"<td>" + x[0].getElementsByTagName("YEAR")[0].childNodes[0].nodeValue + "</td>"+
"</tr></table>"  */
  
  "<b>ФИО: </b>" + x[0].getElementsByTagName("NAME")[0].childNodes[0].nodeValue + "<br\/>"+
"<b>Факультет: </b>" + x[0].getElementsByTagName("FACULTY")[0].childNodes[0].nodeValue + "<br\/>"+
"<b>Специальность: </b>" + x[0].getElementsByTagName("SPECIALITY")[0].childNodes[0].nodeValue + "<br\/>"+
"<b>Группа: </b>" + x[0].getElementsByTagName("GROUP")[0].childNodes[0].nodeValue + "<br\/>"+
"<b>Год: &copy;</b>" + x[0].getElementsByTagName("YEAR")[0].childNodes[0].nodeValue + "<br\/>"; 

}