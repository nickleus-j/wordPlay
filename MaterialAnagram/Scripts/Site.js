function LoadAnagram(str, consoleElemId) {
    var dt1 = new Date();
    $(consoleElemId).text('');
    WriteLine(sampleAnagram(), consoleElemId);
    WriteLine(FindAllPermutations(str), consoleElemId);
    var dt2 = new Date();
    WriteLine("Code took " + (dt2.getTime() - dt1.getTime()) + " milliseconds to execute", consoleElemId);
}

function sampleAnagram() {
    var words = new Array("Dog", "dOg", "God", "doggy", "dogg", "Zebra", "Wood");
    var unique = {},result="";

    // iterate over all the words
    for (i = 0; i < words.length; i++) {

        // get the word, all lowercase
        var word = words[i].toLowerCase();

        // sort the word's letters
        word = word.split('').sort().join('')

        // keep a count of unique combinations
        if (unique[word]) {
            unique[word] += 1;
            result += (word+ "<br/>");
        }
        else
            unique[word] = 1;
    }

    // print the histogram
    for (u in unique)
        result += (u + ": " + unique[u] + "<br/>");
    return result;
}

function FindAllPermutations(str, index, buffer) {
    if (typeof str == "string")
        str = str.split("");
    if (typeof index == "undefined")
        index = 0;
    if (typeof buffer == "undefined")
        buffer = [];
    if (index >= str.length)
        return buffer;
    for (var i = index; i < str.length; i++)
        buffer.push(ToggleLetters(str, index, i));
    return FindAllPermutations(str, index + 1, buffer);
}

function ToggleLetters(str, index1, index2) {
    if (index1 != index2) {
        var temp = str[index1];
        str[index1] = str[index2];
        str[index2] = temp;
    }
    return str.join("") + "<br/>";
}

function WriteLine(msg, consoleElemId) {
    $(consoleElemId).append(msg + "<br />");
}