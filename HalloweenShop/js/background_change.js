//Обязательно должен быть снизу, ибо срабатывает после загрузки страницы. 
var date = new Date(); //текущая дата
var h =   date.getHours();/* это текущий час  */


if(h >= 0 && h <= 3 ) { 
       
        document.body.style.background = " #00001a url(images/background_night.jpg)";
	   document.body.style.backgroundRepeat = "no-repeat";
      document.body.style.backgroundPosition = "center center";
      document.body.style.backgroundAttachment = "fixed";
      document.body.style.backgroundSize = "cover";
		
}
else if(h >= 4 && h <= 6) {
    
	  document.body.style.background = "#00001a url(images/background_beforemorning.jpg)";
      document.body.style.backgroundRepeat = "no-repeat";
      document.body.style.backgroundPosition = "center center";
      document.body.style.backgroundAttachment = "fixed";
      document.body.style.backgroundSize = "cover"; 
   	
}
else if(h >= 7 && h <= 10) {
      document.body.style.background = "#ffa161 url(images/background_morning.jpg)";
		document.body.style.backgroundRepeat = "no-repeat";
        document.body.style.backgroundPosition = "center center";
        document.body.style.backgroundAttachment = "fixed";
        document.body.style.backgroundSize = "cover";
		   document.getElementById('popSection').style.color = 'gold';	
		   document.getElementById('popSection').style.textShadow = '1px 1px 2px red, 0 0 1em yellow';
		    document.getElementById('popSection').style.webkitTextStroke = '1.5px black';
		  document.getElementById('popGoods').style.color = 'gold';	
		   document.getElementById('popGoods').style.textShadow = '1px 1px 2px red, 0 0 1em yellow';
		   document.getElementById('popGoods').style.webkitTextStroke = '1.5px black';
		    
		
}
else if(h >= 11 && h <= 16) {
      document.body.style.background = "#ffa161 url(images/background_general.jpg)";
		document.body.style.backgroundRepeat = "no-repeat";
        document.body.style.backgroundPosition = "bottom center";
        document.body.style.backgroundAttachment = "fixed";
        document.body.style.backgroundSize = "cover";  
		
		  document.getElementById('popSection').style.color = 'red';	
		   document.getElementById('popSection').style.textShadow = '1px 1px 2px black';
		     document.getElementById('popSection').style.webkitTextStroke = '1.5px black';
			 
		  document.getElementById('popGoods').style.color = 'red';	
		   document.getElementById('popGoods').style.textShadow = '1px 1px 2px black';
		     document.getElementById('popGoods').style.webkitTextStroke = '1.5px black';
}
else if(h >= 17 && h <= 20) {
       document.body.style.background = "#ffa161 url(images/background_beforetwilight.jpg)";
		document.body.style.backgroundRepeat = "no-repeat";
        document.body.style.backgroundPosition = "center center";
        document.body.style.backgroundAttachment = "fixed";
        document.body.style.backgroundSize = "cover";
		
		  document.getElementById('popSection').style.color = 'red';	
		   document.getElementById('popSection').style.textShadow = '1px 1px 2px black, 0 0 1em yellow';
		    document.getElementById('popSection').style.webkitTextStroke = '1.5px black';
		  
		  document.getElementById('popGoods').style.color = 'red';	
		   document.getElementById('popGoods').style.textShadow = '1px 1px 2px black';
		     document.getElementById('popGoods').style.webkitTextStroke = '1.5px black';
			 
}
else if(h >= 21 && h <= 23) {
    document.body.style.background = "#00001a url(images/background_twilight.jpg)";
     document.body.style.backgroundRepeat = "no-repeat";
        document.body.style.backgroundPosition = "center center";
        document.body.style.backgroundAttachment = "fixed";
        document.body.style.backgroundSize = "cover"; 
		
		
}
