function writeSpan(msg, cssClass, consoleElemId) {
    var elem = "<span class='" + cssClass + "'>" + msg + "</span>";
    $(consoleElemId).append(elem + "<br />");
}

function WriteLine(msg, consoleElemId) {
    $(consoleElemId).append(msg + "<br />");
}

function findAnagrams(str, consoleElemId) {
    $(consoleElemId).text('');
    var dt1 = new Date();
    $.post("/Anagram/AnagramGen", { "givenText": str.toLowerCase() }, function (data) {
        data=JSON.parse(data);
        for (var ctr = 0; ctr < data.length;ctr++){
            WriteLine(data[ctr], consoleElemId);
        }
        var dt2 = new Date();
        writeSpan("Code took " + (dt2.getTime() - dt1.getTime()) + " milliseconds to execute","smallLabel", consoleElemId);
    });
}

function CaeserEncryption(str, consoleElemId) {
    $.post("/Cipher/CaeserEncryption", { "givenText": str.toLowerCase() }, function (data) {
        $(consoleElemId).text(data);
    });
}
