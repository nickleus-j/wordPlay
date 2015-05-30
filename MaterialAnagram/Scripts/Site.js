function writeSpan(msg, cssClass, consoleElemId) {
    var elem = "<span class='" + cssClass + "'>" + msg + "</span>";
    $(consoleElemId).append(elem + "<br />");
}

function WriteLine(msg, consoleElemId) {
    $(consoleElemId).append(msg + "<br />");
}

function findAnagrams(str, consoleElemId) {
    $(consoleElemId).text('');
    str = str.split(" ");
    for (var word in str) {
        findAnagram(str[word], consoleElemId);
    }
   
}

function findAnagram(str, consoleElemId) {
    $.post("/Anagram/AnagramGen", { "givenText": str.toLowerCase() }, function (data) {
        data = JSON.parse(data);
        WriteLine(" | " + str + " | ", consoleElemId);
        for (var ctr = 0; ctr < data.length; ctr++) {
            WriteLine(data[ctr], consoleElemId);
        }
        
    });
}

function CaeserEncryption(str, consoleElemId) {
    $.post("/Cipher/CaeserEncryption", { "givenText": str.toLowerCase() }, function (data) {
        $(consoleElemId).text(data);
    });
}
function AesEncryption(str, consoleElemId) {
    $.post("/Cipher/GetAESResult", { "givenText": str}, function (data) {
        $(consoleElemId).text(data);
    });
}
