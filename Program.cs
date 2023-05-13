using HtmlAgilityPack;

string path = @"/Users/billdev/repos/doingazure/HtmlChecker/results.html";
string html = File.ReadAllText(path);
var doc = new HtmlDocument();
doc.LoadHtml(html);

var resultListNode = doc.DocumentNode.SelectSingleNode(".//div[@id='results']/ol");

var fatalItems = resultListNode.SelectNodes("li[@class='non-document-error io']"); // https://validator.w3.org/nu/?doc=https%3A%2F%2Fwww.gutenberg.org%2Fcache%2Fepub%2F20228%2Fpg20228.txt
var errorItems = resultListNode.SelectNodes("li[@class='error']");
var warningItems = resultListNode.SelectNodes("li[@class='warning']");
var infoItems = resultListNode.SelectNodes("li[@class='info']");
var resultItems = resultListNode.SelectNodes("li"); // ALL IN TOTAL

var fatalCount = fatalItems?.Count ?? 0;
var errorCount = errorItems?.Count ?? 0;
var warningCount = warningItems?.Count ?? 0;
var infoCount = infoItems?.Count ?? 0;
var resultCount = resultItems?.Count ?? 0;

//foreach (var resultItem in errorItems) // resultListNode.SelectNodes("li[@class='error']")) // 
foreach (var resultItem in errorItems) // resultListNode.SelectNodes("li[@class='error']")) // 
{
    Console.WriteLine("Ding: " + (resultItem?.InnerText ?? "none"));
}

//Console.WriteLine("WithBoldText: " + (resultListNode?.InnerText ?? "none"));

Console.WriteLine($"{fatalCount} fatals + {errorCount} errors + {warningCount} warnings + {infoCount} infos = {resultCount} TOTAL RESULTS");

