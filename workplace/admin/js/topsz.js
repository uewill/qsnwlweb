// JavaScript Document
<!--    
//=======================================================    
//函数名称：getObject(objectId)    
//          参数objectId:控件的ID值    
//函数功能：获得控件的ID值    
//返 回 值：ture(获得ID值) false(获取ID失败)    
//=======================================================    
function getObject(objectId) {    
    if(document.getElementById && document.getElementById(objectId)) {    
    // W3C DOM    
    return document.getElementById(objectId);    
    } else if (document.all && document.all(objectId)) {    
    // MSIE 4 DOM    
    return document.all(objectId);    
    } else if (document.layers && document.layers[objectId]) {    
    // NN 4 DOM.. note: this won't find nested layers    
    return document.layers[objectId];    
    } else {    
    return false;    
    }    
}    
   
// 显示列表框    
function displayList(){        
          var h = getObject('class_cnt1').offsetHeight;  // 内容容器class_cnt1的初始高度（这时高度为：0）    
          var max_h = 67; // 容器的最大高度    
              
          var anim = function(){                
                    h += 66; // 每次递增50像素    
                    //如果增加的高度开始超过容的最大高度    
                    if(h >= max_h){     
                    getObject('class_cnt1').style.height = "67px"; // 工期高度为287px(因为我们只希望容器这么高)    
                    //getObject('tabclass1').style.backgroundImage="url(http://www.east-dragon.cn/files/sw/images/tab_drop1.gif)"; // 让图片标签改变背景               
                    if(tt){window.clearInterval(tt);} // 如果高度在每2毫秒递减，则清楚改行为（如果不清楚，程序将一直自动运行高度每2毫秒递减）    
                    }    
                    else{ // 如果增加中的容器高度没有超过287px    
                getObject('class_cnt1').style.display="block"; // 让容器可见（这样我们才能够看到容器在增高的效果）    
                getObject('class_cnt1').style.height = h + "px"; // 容器高度不断的以50px递增    
                    }    
            }    
                   
              var tt = window.setInterval(anim,2);  // 设置每2毫秒循环一次（每2毫秒，运行一次anim[容器的高度递减50px]）        
}    
   
// 隐藏列表框    
function hiddenList(){    
       var h = getObject('class_cnt1').offsetHeight; // 内容容器class_cnt1的初始高度（这时高度为：287px）    
           var anim = function(){    
                 h -= 66; // 每次递减50像素    
                     
                 if(h <= 5){    
                 getObject('class_cnt1').style.display="none"; // 内容容器不可见（当容器高度小于5px）    
                   //getObject('tabclass1').style.backgroundImage="url(http://www.east-dragon.cn/files/sw/images/tab_drop2.gif)";     
                   if(tt){window.clearInterval(tt);}    
               }    
               else{    
                   getObject('class_cnt1').style.height = h + "px"; // // 容器高度不断的以50px递减     
               }    
           }    
                 
           var tt = window.setInterval(anim,2); // 设置每2毫秒循环一次（每2毫秒，运行一次anim[容器的高度递减50px]）    
}    
   
//=======================================================    
//函数名称：showClassList()    
//函数功能：隐藏-显示级分类列表框（class_cnt1）   横向折叠 
//返 回 值：无    
//=======================================================    
function showClassList(){    
    // 如果内容容器为不可见的display:none    
    if(getObject('class_cnt1').style.display == "none"){     
        displayList(); // 显示内容框    
    }    
    else{ // 如果内容容器为可见的display:block    
        hiddenList(); // 隐藏内容框    
    }    
}

//竖向折叠
function showhidediv(id) {
    var sbtitle = document.getElementById(id);
    if (sbtitle) {
        if (sbtitle.style.display == 'block') {
            sbtitle.style.display = 'none';
        } else {
            sbtitle.style.display = 'block';
        }
    }
}    
-->   