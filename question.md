# TECHNICAL QUESTION
## 1. How long did you spend on the coding test?
   16hours estimated
## 2. What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.
    1. Create a custom response model for the Survivors endpoint
    2. Make the trade interactive using SignalR(websocket) instead of request and response through API
    3. Design an interface to make the User experience seemless
     
## 3. How would you track down a performance issue in production? Have you ever had to do this?
    I have not done this before but i will address it in this manner
    1. Check CPU and Memory Usage of the server and find out pprocesses that consumes memory
    2. Integrate a monitoring tool like Application Insight to get extensive knowledge of the performance
    
## 4. How would you improve the APIs that you just created? 
    1. Use a stored procedure to perform the Request trade. there seems to be so many calls to the database in a single method
    2. Paginate the Query Enpoints
