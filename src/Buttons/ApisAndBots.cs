using System;
using Python_WRD.Components;

namespace Python_WRD.Buttons
{
    internal class ApisAndBots
    {
        public static void _1(object sender, EventArgs e)
        {
            string _1 = @"from telegram.ext import Updater, CommandHandler

def start(update, context):
    update.message.reply_text(""Hello! I'm your bot."")

updater = Updater('YOUR_TOKEN_HERE')
updater.dispatcher.add_handler(CommandHandler('start', start))

updater.start_polling()
updater.idle()";

            OpenCodeWindowHandler.OpenCodeWindow(_1);
        }

        public static void _2(object sender, EventArgs e)
        {
            string _2 = @"import requests

API_KEY = ""your_openweathermap_api_key""
CITY = ""London""

url = f""http://api.openweathermap.org/data/2.5/weather?q={CITY}&appid={API_KEY}&units=metric""

response = requests.get(url)
data = response.json()

if data[""cod""] == 200:
    weather = data[""weather""][0][""description""]
    temperature = data[""main""][""temp""]
    print(f""Weather in {CITY}: {weather.capitalize()}, {temperature}°C"")
else:
    print(f""Error: {data['message']}"")";

            OpenCodeWindowHandler.OpenCodeWindow(_2);
        }

        public static void _3(object sender, EventArgs e)
        {
            string _3 = @"import tweepy

API_KEY = ""your_api_key""
API_SECRET_KEY = ""your_api_secret_key""
ACCESS_TOKEN = ""your_access_token""
ACCESS_TOKEN_SECRET = ""your_access_token_secret""

auth = tweepy.OAuth1UserHandler(API_KEY, API_SECRET_KEY, ACCESS_TOKEN, ACCESS_TOKEN_SECRET)
api = tweepy.API(auth)

tweet = ""Hello, Twitter! This is a tweet from my Python bot.""
api.update_status(tweet)
print(""Tweet posted!"")
";

            OpenCodeWindowHandler.OpenCodeWindow(_3);
        }

        public static void _4(object sender, EventArgs e)
        {
            string _4 = @"import requests

WEBHOOK_URL = ""your_slack_webhook_url""

message = {
    ""text"": ""Hello, Slack! This message is sent from my Python bot.""
}

response = requests.post(WEBHOOK_URL, json=message)

if response.status_code == 200:
    print(""Message sent to Slack!"")
else:
    print(f""Failed to send message. Error: {response.status_code}"")
";

            OpenCodeWindowHandler.OpenCodeWindow(_4);
        }

        public static void _5(object sender, EventArgs e)
        {
            string _5 = @"import discord

TOKEN = ""your_discord_bot_token""

intents = discord.Intents.default()
intents.members = True
client = discord.Client(intents=intents)

@client.event
async def on_ready():
    print(f""Logged in as {client.user}"")

@client.event
async def on_member_join(member):
    channel = discord.utils.get(member.guild.text_channels, name=""general"")
    if channel:
        await channel.send(f""Welcome to the server, {member.mention}!"")

client.run(TOKEN)
";

            OpenCodeWindowHandler.OpenCodeWindow(_5);
        }

        public static void _6(object sender, EventArgs e)
        {
            string _6 = @"from telegram.ext import Updater, CommandHandler, MessageHandler, Filters
import openai

openai.api_key = ""YOUR_OPENAI_API_KEY""

def chat_with_gpt(update, context):
    user_message = update.message.text
    response = openai.Completion.create(
        engine=""text-davinci-003"",
        prompt=user_message,
        max_tokens=100
    )
    bot_reply = response.choices[0].text.strip()
    update.message.reply_text(bot_reply)

def main():
    updater = Updater('YOUR_TELEGRAM_BOT_TOKEN')
    dp = updater.dispatcher

    dp.add_handler(MessageHandler(Filters.text & ~Filters.command, chat_with_gpt))

    updater.start_polling()
    updater.idle()

if __name__ == '__main__':
    main()
";

            OpenCodeWindowHandler.OpenCodeWindow(_6);
        }

        public static void _7(object sender, EventArgs e)
        {
            string _7 = @"import requests

REPO = ""octocat/Hello-World""  # Replace with your target repository

url = f""https://api.github.com/repos/{REPO}""

response = requests.get(url)
if response.status_code == 200:
    data = response.json()
    print(f""Repository: {data['name']}"")
    print(f""Description: {data['description']}"")
    print(f""Stars: {data['stargazers_count']}"")
    print(f""Forks: {data['forks_count']}"")
    print(f""Open Issues: {data['open_issues_count']}"")
else:
    print(f""Error: {response.status_code}"")
";

            OpenCodeWindowHandler.OpenCodeWindow(_7);
        }

        public static void _8(object sender, EventArgs e)
        {
            string _8 = @"from twilio.rest import Client

ACCOUNT_SID = 'your_account_sid'
AUTH_TOKEN = 'your_auth_token'

client = Client(ACCOUNT_SID, AUTH_TOKEN)

def send_whatsapp_message(to_number, message):
    from_number = ""whatsapp:+14155238886""  # Twilio's sandbox number
    client.messages.create(
        from_=from_number,
        body=message,
        to=f""whatsapp:{to_number}""
    )
    print(""Message sent!"")

if __name__ == ""__main__"":
    send_whatsapp_message(""+1234567890"", ""Hello! This is a test message from my bot."")
";

            OpenCodeWindowHandler.OpenCodeWindow(_8);
        }

        public static void _9(object sender, EventArgs e)
        {
            string _9 = @"import requests

API_KEY = ""your_youtube_api_key""
VIDEO_ID = ""dQw4w9WgXcQ""  # Replace with your target YouTube video ID

url = f""https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={VIDEO_ID}&key={API_KEY}""

response = requests.get(url)
if response.status_code == 200:
    data = response.json()
    video = data['items'][0]
    title = video['snippet']['title']
    views = video['statistics']['viewCount']
    likes = video['statistics']['likeCount']
    print(f""Title: {title}"")
    print(f""Views: {views}"")
    print(f""Likes: {likes}"")
else:
    print(f""Error fetching video details: {response.status_code}"")
";

            OpenCodeWindowHandler.OpenCodeWindow(_9);
        }
    }
}
