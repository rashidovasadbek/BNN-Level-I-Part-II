// See https://aka.ms/new-console-template for more information
using N56__HT1.Extensions;
using N56__HT1.Models;
using N56__HT1.Services;

var userA = new User(Guid.Parse("6198a3f5-f5b6-45db-8e1a-4561f71dd111"), "userA");
var userB = new User(Guid.Parse("b1f4efa3-c2bc-42be-9c49-25b361d25572"), "userB");
var userC = new User(Guid.Parse("562107b0-1f65-4899-ae57-4c9b6f50bba6"), "userC");
var userD = new User(Guid.Parse("104a294f-c2b0-4e3c-94ec-c98c50dbbd1f"), "userD");
var userE = new User(Guid.Parse("e6acaa18-bebf-424c-ab32-af6cf010a5e2"), "userE");
var userF = new User(Guid.Parse("51932736-a907-47d4-b5a0-a5e78787e1e3"), "userF");
var userG = new User(Guid.Parse("be9809fc-7135-46ec-bc61-943d3198df4e"), "userG");
var userH = new User(Guid.Parse("be151f14-3e15-420a-a903-80ad158e8f82"), "userH");

userA.InitializeUserFoldersAsync();
userB.InitializeUserFoldersAsync();
userC.InitializeUserFoldersAsync();
userD.InitializeUserFoldersAsync();
userE.InitializeUserFoldersAsync();
userF.InitializeUserFoldersAsync();
userG.InitializeUserFoldersAsync();
userH.InitializeUserFoldersAsync();

var directory = new DirectoryService();
var files = new FileService();
var cleanUpService = new CleanUpService(directory, files);

var cleanUp = await cleanUpService.CleanUpfile(userD);
cleanUp.ForEach(Console.WriteLine);
