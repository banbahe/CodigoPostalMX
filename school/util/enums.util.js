// var StatusItem = {"ENABLE":1 ,"DISABLE":2};
// Object.freeze(StatusItem);

// const StatusItem = {
//     "ENABLE": 1,
//     "DISABLE": 2
// };

// module.exports = StatusItem;

module.exports = {
    StatusItem : {
        "ENABLE": 1,
        "DISABLE": 2
    },
    DateTimeNowToMilliSeconds :  function(){
        var d = new Date();
        var n = d.getTime();
        return n;
    }

}