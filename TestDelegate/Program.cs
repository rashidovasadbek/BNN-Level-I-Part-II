using Delegates.Example.Extensions;

using TestDelegate.Model;

var topicA = new Topic(1, "book");

var topicsA = new List<Topic>()
{
    new Topic(1, "JS"),
    new Topic(2, "TS"),
    new Topic(3, "CS"),
};

var topicsB = new List<Topic>()
{
    new Topic(1, "Javascript"),
    new Topic(2, "Typescript"),
    new Topic(3, "CSharp"),
};


var oldPost = new PostA(1, topicsA, "bookMarket", "booked");
var updatedPost = new PostA(2, topicsB, "", "");


var intersectedPosts = oldPost.Topics.ZipIntersectBy(updatedPost.Topics, topic => topic.Id);

foreach (var (old, up) in intersectedPosts)
{
    Console.WriteLine($"Skill eski qiymatlari - {old.Name}");
    Console.WriteLine($"Skill yangi qiymatlari - {up.Name}");
}