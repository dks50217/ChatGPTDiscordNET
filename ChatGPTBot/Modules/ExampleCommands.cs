using Discord;
using Discord.Commands;
using ChatGPTBot.OpenAI;
using RunMode = Discord.Commands.RunMode;

namespace ChatGPTBot.Modules;

public class ExampleCommands : ModuleBase<ShardedCommandContext>
{
    public CommandService CommandService { get; set; }

    [Command("hello", RunMode = RunMode.Async)]
    public async Task Hello()
    {
        await Context.Message.ReplyAsync($"Hello {Context.User.Username}. Nice to meet you!");
    }

    [Command("chatgpt", RunMode = RunMode.Async)]
    public async Task ChatGPT([Remainder] string text)
    {
        var result = ChatGPTHelper.CallChatGPT(text);
        var message = result.choices.FirstOrDefault().text;
        await Context.Message.ReplyAsync(message);
    }
}