using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python_WRD.Components;

namespace Python_WRD.Buttons
{
    internal class WebApps
    {
        public static void _1(object sender, EventArgs e)
        {
            string _1 = @"from flask import Flask

app = Flask(__name__)

@app.route('/')
def home():
    return ""Hello, Web App!""

if __name__ == '__main__':
    app.run(debug=True)
";
            OpenCodeWindowHandler.OpenCodeWindow(_1);
        }

        public static void _2(object sender, EventArgs e)
        {
            string _2 = @"from flask import Flask, request
import requests

app = Flask(__name__)

# Your API key for OpenWeatherMap
API_KEY = ""your_openweather_api_key""
WEATHER_URL = ""http://api.openweathermap.org/data/2.5/weather""

@app.route(""/"", methods=[""GET"", ""POST""])
def index():
    weather_data = None
    error = None
    
    if request.method == ""POST"":
        city = request.form.get(""city"")
        if city:
            params = {
                ""q"": city,
                ""appid"": API_KEY,
                ""units"": ""metric"",
                ""lang"": ""en""
            }
            response = requests.get(WEATHER_URL, params=params)
            
            if response.status_code == 200:
                weather_data = response.json()
            else:
                error = ""Could not fetch weather data. Please check the city name.""
    
    return f""""""
    <!DOCTYPE html>
    <html lang=""en"">
    <head>
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <title>WeatherWhisperer</title>
    </head>
    <body>
        <h1>Check the Weather in Your City</h1>
        <form method=""POST"">
            <input type=""text"" name=""city"" placeholder=""Enter city name"" required>
            <button type=""submit"">Get Weather</button>
        </form>
        
        {""<p style='color: red;'>"" + error + ""</p>"" if error else """"}
        
        {f""""""
        <h2>Weather in {weather_data['name']}</h2>
        <p>Temperature: {weather_data['main']['temp']}°C</p>
        <p>Humidity: {weather_data['main']['humidity']}%</p>
        <p>Description: {weather_data['weather'][0]['description']}</p>
        """""" if weather_data else """"}
    </body>
    </html>
    """"""

if __name__ == ""__main__"":
    app.run(debug=True)
            ";
            OpenCodeWindowHandler.OpenCodeWindow(_2);
        }

        public static void _3(object sender, EventArgs e)
        {
            string _3 = @"from flask import Flask, render_template, request, redirect
import sqlite3

app = Flask(__name__)

# Create database and table
conn = sqlite3.connect(""notes.db"", check_same_thread=False)
conn.execute(""CREATE TABLE IF NOT EXISTS notes (id INTEGER PRIMARY KEY, content TEXT)"")

@app.route(""/"")
def index():
    notes = conn.execute(""SELECT * FROM notes"").fetchall()
    return f""""""
    <h1>NoteKeeper</h1>
    <form action=""/add"" method=""POST"">
        <textarea name=""content"" placeholder=""Write your note here..."" required></textarea>
        <button type=""submit"">Add Note</button>
    </form>
    <ul>
        {''.join(f""<li>{note[1]} <a href='/delete/{note[0]}'>Delete</a></li>"" for note in notes)}
    </ul>
    """"""

@app.route(""/add"", methods=[""POST""])
def add_note():
    content = request.form.get(""content"")
    conn.execute(""INSERT INTO notes (content) VALUES (?)"", (content,))
    conn.commit()
    return redirect(""/"")

@app.route(""/delete/<int:note_id>"")
def delete_note(note_id):
    conn.execute(""DELETE FROM notes WHERE id=?"", (note_id,))
    conn.commit()
    return redirect(""/"")

if __name__ == ""__main__"":
    app.run(debug=True)";
            OpenCodeWindowHandler.OpenCodeWindow(_3);
        }

        public static void _4(object sender, EventArgs e)
        {
            string _4 = @"from flask import Flask, request, render_template_string, redirect

app = Flask(__name__)

poll_data = {""question"": ""What's your favorite color?"", ""options"": [""Red"", ""Blue"", ""Green"", ""Yellow""], ""votes"": [0, 0, 0, 0]}

@app.route(""/"")
def poll():
    options = """".join(f""<button type='submit' name='vote' value='{i}'>{option}</button><br>"" for i, option in enumerate(poll_data[""options""]))
    return f""""""
    <h1>{poll_data['question']}</h1>
    <form method=""POST"" action=""/vote"">
        {options}
    </form>
    <a href='/results'>View Results</a>
    """"""

@app.route(""/vote"", methods=[""POST""])
def vote():
    vote = int(request.form.get(""vote""))
    poll_data[""votes""][vote] += 1
    return redirect(""/results"")

@app.route(""/results"")
def results():
    results = """".join(f""<p>{option}: {votes} votes</p>"" for option, votes in zip(poll_data[""options""], poll_data[""votes""]))
    return f""""""
    <h1>Poll Results</h1>
    {results}
    <a href='/'>Back to Poll</a>
    """"""

if __name__ == ""__main__"":
    app.run(debug=True)";
            OpenCodeWindowHandler.OpenCodeWindow(_4);
        }

        public static void _5(object sender, EventArgs e)
        {
            string _5 = @"from flask import Flask, request, redirect, url_for
import os

app = Flask(__name__)
UPLOAD_FOLDER = ""uploads""
os.makedirs(UPLOAD_FOLDER, exist_ok=True)
app.config[""UPLOAD_FOLDER""] = UPLOAD_FOLDER

@app.route(""/"")
def index():
    files = os.listdir(UPLOAD_FOLDER)
    file_links = """".join(f""<li><a href='/uploads/{file}'>{file}</a></li>"" for file in files)
    return f""""""
    <h1>MiniFileUploader</h1>
    <form action=""/upload"" method=""POST"" enctype=""multipart/form-data"">
        <input type=""file"" name=""file"" required>
        <button type=""submit"">Upload</button>
    </form>
    <ul>{file_links}</ul>
    """"""

@app.route(""/upload"", methods=[""POST""])
def upload_file():
    file = request.files[""file""]
    file.save(os.path.join(app.config[""UPLOAD_FOLDER""], file.filename))
    return redirect(""/"")

@app.route(""/uploads/<filename>"")
def uploaded_file(filename):
    return f""<h1>{filename}</h1><p>File uploaded successfully!</p>""

if __name__ == ""__main__"":
    app.run(debug=True)";
            OpenCodeWindowHandler.OpenCodeWindow(_5);
        }

        public static void _6(object sender, EventArgs e)
        {
            string _6 = @"from flask import Flask
import requests

app = Flask(__name__)

@app.route(""/"")
def quote():
    response = requests.get(""https://api.quotable.io/random"")
    data = response.json()
    return f""""""
    <h1>Random Quote</h1>
    <p>{data['content']}</p>
    <p><i>- {data['author']}</i></p>
    <a href=""/"">Get Another Quote</a>
    """"""

if __name__ == ""__main__"":
    app.run(debug=True)";
            OpenCodeWindowHandler.OpenCodeWindow(_6);
        }

        public static void _7(object sender, EventArgs e)
        {
            string _7 = @"from flask import Flask, request
from datetime import datetime
import pytz

app = Flask(__name__)

@app.route(""/"", methods=[""GET"", ""POST""])
def timezone_converter():
    converted_time = """"
    if request.method == ""POST"":
        time = request.form.get(""time"")
        tz_from = request.form.get(""from_tz"")
        tz_to = request.form.get(""to_tz"")
        try:
            from_zone = pytz.timezone(tz_from)
            to_zone = pytz.timezone(tz_to)
            local_time = from_zone.localize(datetime.strptime(time, ""%Y-%m-%d %H:%M""))
            converted_time = local_time.astimezone(to_zone).strftime(""%Y-%m-%d %H:%M"")
        except Exception:
            converted_time = ""Invalid Input""
    
    return f""""""
    <h1>Timezone Converter</h1>
    <form method=""POST"">
        <input type=""text"" name=""time"" placeholder=""YYYY-MM-DD HH:MM"" required>
        <input type=""text"" name=""from_tz"" placeholder=""From Timezone (e.g., UTC)"" required>
        <input type=""text"" name=""to_tz"" placeholder=""To Timezone (e.g., Asia/Kolkata)"" required>
        <button type=""submit"">Convert</button>
    </form>
    {""<p>Converted Time: "" + converted_time + ""</p>"" if converted_time else """"}
    """"""

if __name__ == ""__main__"":
    app.run(debug=True)";
            OpenCodeWindowHandler.OpenCodeWindow(_7);
        }
    }
}
