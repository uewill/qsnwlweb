// JavaScript Document
function  Year_Month(){  
        var  now  =  new  Date();  
        var  yy  =  now.getYear();  
        var  mm  =  now.getMonth();  
	var  mmm=new  Array();
	mmm[0]="1";
	mmm[1]="2";
	mmm[2]="3";
	mmm[3]="4";
	mmm[4]="5";
	mmm[5]="6";
	mmm[6]="7";
	mmm[7]="8";
	mmm[8]="9";
	mmm[9]="10";
	mmm[10]="11";
	mmm[11]="12";
	mm=mmm[mm];
        return(mm  );  }
function  thisYear(){  
        var  now  =  new  Date();  
        var  yy  =  now.getFullYear();  
        return(yy  );  }
function  Date_of_Today(){  
        var  now  =  new  Date();  
        return(now.getDate()  );  }
function  Date_of_Week(){  
        var  now  =  new  Date();  
        var week=now.getDay();
		var week_day
		if(week==1){ week_day="星期一"};
		if(week==2){ week_day="星期二"};
		if(week==3){ week_day="星期三"};
		if(week==4){ week_day="星期四"};
		if(week==5){ week_day="星期五"};
		if(week==6){ week_day="星期六"};
		if(week==0){ week_day="星期日"};
		return(week_day);
		 }
function  CurentTime(){  
        var  now  =  new  Date();  
        var  hh  =  now.getHours();  
        var  mm  =  now.getMinutes();  
        var  ss  =  now.getTime()  %  60000;  
        ss  =  (ss  -  (ss  %  1000))  /  1000;  
        var  clock  =  hh+':';  
        if  (mm  <  10)  clock  +=  '0';  
        clock  +=  mm+':';  
        if  (ss  <  10)  clock  +=  '0';  
        clock  +=  ss;  
        return(clock);  }  
function  refreshCalendarClock(){  
document.getElementById("calendarClock1").innerHTML  =  Year_Month()+"月";  
document.getElementById("calendarClock2").innerHTML  =  Date_of_Today()+"日";  
document.getElementById("calendarClock3").innerHTML  =thisYear()+"年";
document.getElementById("calendarClock5").innerHTML  =  Date_of_Week();  
document.getElementById("calendarClock4").innerHTML  =  CurentTime();
}
document.write('&nbsp;<font  id="calendarClock3"  >  </font>');
document.write('<font  id="calendarClock1"  >  </font>');
document.write('<font  id="calendarClock2"  >  </font>');
document.write('<font  id="calendarClock5"  >  </font>&nbsp;&nbsp;');
document.write('<font  id="calendarClock4"  >  </font>');
setInterval('refreshCalendarClock()',1000);
