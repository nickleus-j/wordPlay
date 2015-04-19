

function WriteLine(msg, consoleElemId) {
    $(consoleElemId).append(msg + "<br />");
}
//$.post("/Qr/MakeQrCode", { "givenUrl": givenUrl }, function (data) {
function findAnagrams(str, consoleElemId) {
    $(consoleElemId).text('');
    var dt1 = new Date();
    $.post("/Anagram/AnagramGen", { "givenText": str.toLowerCase() }, function (data) {
        data=JSON.parse(data);
        for (var ctr = 0; ctr < data.length;ctr++){
            WriteLine(data[ctr], consoleElemId);
        }
        var dt2 = new Date();
        WriteLine("Code took " + (dt2.getTime() - dt1.getTime()) + " milliseconds to execute", consoleElemId);
    });
}
