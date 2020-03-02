# JobInterviewQuestion
A pre-job interview developer question

A friend of mine went to a job interview and they send over a small task for him to work at and bring to the interview. I wasn't going to that interview, but decided it would be a fun excercise to work at. The task was originally just a 2 hour task that did not need a complete solution, and im not developing the SQL database setup that the full solution would require, but I did spend alot more time on it than the 2 hours, because it turned into a playground for Timers Async methods and API calls. 

The feedback my friend got from his solution was that they liked it, but his classes relied so much on each other that it was impossible to test the different class's methods individually without instantiating all the classes. So a personal requirement for this assignment was that all the methods should be testable independantly of the other classes. 

Here is the excercise:

This following exercise is intended to help aid discussion - there are no wrong answers. You will have to make assumptions to complete the implementation. Please document your assumptions.
Please limit the scope to about 2 hours (we’re not looking for a full solution – it’s up to you where you put the focus) and implemented in C#. Document what you have left out of the scope.

A Truck Plan describes a single driver driving a truck for a continuous period. For example; a five hour drive through Germany on a specific date. A driver is a person with a name, birthdate, etc.
Each truck has a GPS device installed. This device provides the system with the current truck position approximately every 5 minutes.

1. Design and implement a model for representing the domain.
2. Implement functionality to calculate the approximate distance driven for a single TruckPlan.
3. Find a way to get the country from a coordinate. A solution could, for example, be to call an external web service.
4. Implement functionality for answering the following question: "How many kilometers did drivers over the age of 50 drive in Germany in February 2018?"


Progress

1. I havent made the drawn model digital yet, but it is complete.
2. The truckplan can calculate the flight distance between its start and end position using pythagoras, but not yet the full route. 
    - See "Still working on" for details
3. Task is to call an API, so thats what I will do for this part
4. Im going to make a list of tuples <double,double,string> in the GPS and pass it to the truckplan, and then have the truckplan class calculate the distance driven between each coordinate when it is at the end destination. It will then create a new list with the countries(strings) from the previous list and add together the distances driven in that country. This could then be shared with a database, but I am not going that far. 

Still working on:

- Api call is causing internal server errors
- Because Api call is not working I cant make the list yet.








