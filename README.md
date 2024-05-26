# Weather Application

## Overview
This Weather Application retrieves current weather information using the OpenWeatherMap API. It displays temperature, humidity, wind speed for a specified city.

## Features
-**Temperature Conversion:** The application converts the temperature from Kelvin to Celsius and Fahrenheit.
- **Wind Speed Unit Conversion:** The wind speed is displayed in kilometers per hour (km/h) by default.
- **Sunrise and Sunset Times:** The sunrise and sunset times are shown in a short time format.
- **Humidity Information:** Shows the current humidity percentage, indicating the amount of moisture in the air.
- **Detailed Weather Description:** Provides a detailed description of the current weather conditions.
- **Atmospheric Pressure:** Displays the atmospheric pressure.

## Usage
1. Enter the desired city in the provided text box.
2. Click the "Search" button to retrieve and display current weather information.

## Dependencies
- Newtonsoft.Json (Json.NET) for JSON deserialization.

## API Usage
This application utilizes the OpenWeatherMap API for weather data. 

## How to Run
Compile and run the application using your preferred C# development environment.

## Screen from app
![image](https://github.com/LAICEROO/Weather_Application/assets/93771973/e00cd36f-7a36-44dd-a97b-f5bb69fe9ae7)

# Hotel reservation chatbot Project

## Overview
The Harmony Peaks Chatbot Project involves creating an AWS Lambda function and an Amazon Lex bot to handle hotel reservation inquiries at Harmony Peaks. The Lex bot interacts with users to gather reservation details, which are then validated by the Lambda function and stored in DynamoDB.

## Usage
1. Interact with the Bot: Start a conversation with the Lex bot and provide the necessary reservation details (date, time, number of guests).
2. Validation: The bot sends the details to the Lambda function for validation.
3. Response: Based on the validation, the bot either confirms the reservation or asks for corrected details.
4. Storage: Valid reservation details are stored in a DynamoDB table.
