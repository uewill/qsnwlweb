    
//复选修改信息
function GetSelChkFirToModify(foder){
  var res= $("input[@type=checkbox][@checked]").val(); //得到复选框的选中的第一项的值
  if(res==undefined){
   $.dialog.alert("请选择要更新的信息！");
 }else{
    ModifyItems(foder,res);
 }
}
//复选删除列
function DeleteChkItems(tab){
  var res = GetAllSelChkVals();
      if(res.length!=0&&tab.toString().length!=0){
           $.dialog({
    icon: 'confirm',
    content: '确认删除?',
    noFn:function(){},
    yesFn:function(){
         $.ajax({
         type: "get",
         url: "../ImageHadder/DeleteByID.ashx"+"?tabName="+tab+"&ids="+res,
         success: function(msg){
               $.dialog({
            icon: 'succeed',
            time: 1,
            content: '删除成功!',closeFn:function(){
             window.location.reload();
            }
        });   
     },
         error:function(msg){
                  $.dialog({
                icon: 'error',
                  time: 1,
                content: '网络错误!'
            });
          }
    }); 
  }});}
}
//逐条删除需指定表名和编号
function DeleteItems(tab,id){
  if(id.length!=0||tab.toString().length!=0){
  $.dialog({
   content: '确定要删除该记录？',
   icon:'confirm',
    yesFn: function(){
 $.ajax({
     type: "get",
     url: "../ImageHadder/DeleteByID.ashx"+"?tabName="+tab+"&ids="+id,
     success: function(msg){
       $("#trItem_"+id).remove();
     $.dialog({
    icon: 'succeed',
      time: 1,
    content: '删除成功!'
});
     },
     error:function(msg){
     $.dialog({
    icon: 'error',
      time: 1,
    content: '删除失败!'
});
      }
    }); 
    },
    noFn: true //为true等价于function(){}

  });
  }
}
 
//获取复选中的值
 function GetAllSelChkVals(){
    var res = "";
   $("input[@type=checkbox][@checked]").each(function(){ //由于复选框一般选中的是多个,所以可以循环输出
    res+=($(this).val())+",";
    });
    if(res.length==0){
        $.dialog.alert("未选择信息！");
    }else{
       res = res.substring(0,res.length-1);
    }
    return res;
 }
 
 //添加信息
  function addItems(foder,obj){
       $.dialog.open('../'+foder+'/Action.aspx?type=add&code='+obj,{
       title:'添加信息',
       id:'addArt'
 });
  }
 //修改编辑
  function ModifyItems(foder,obj){
   $.dialog.open('../'+foder+'/Action.aspx?type=modify&id='+obj,{
   title:'修改信息',
   id:'editArt'
   });
 }
 
  //打开指定窗口
  function openWindow(urlPath,title,artID){
   $.dialog.open("../"+urlPath,{
   title:title,
   id:artID
   });
 }