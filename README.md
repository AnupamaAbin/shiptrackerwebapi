# Project Name

WebAPIShipManagement: Rest API for shipmanagement/tracking.

## Installation

Visual Studio 2019 
Install the relevent packeages for enabling Swagger,EntityFramework etc.
1. Swashbuckle.AspNetCore
2. Newtonsoft.Json
3. Microsoft.AspNetCore.Identity.EntityFrameworkCore

## Usage
Port data will be updated from the seed file once application starts.
User can use the below functions for manage ship data.
### 1. Add Ship Details
    https://localhost:44314/api/ship
###
        Sample Input:
               {
              "shipname":"Harvey Deep Sea",
              "longitude":22.339914,
              "latitude":114.881014,
              "velocity":12.45
            }
### 2. Get all ship details
```
https://localhost:44314/api/ship
``` 
### 3. Edit ship details
https://localhost:44314/api/ship/{shipId}
 eg : https://localhost:44314/api/ship/1
Sample Input:
```
                {
                  "shipname": "Harvey Deep Sea",
                  "longitude": 121.39,
                  "latitude": 38.34,
                  "velocity": 17.45
                }
```

### 4.Finding Closet port and estimated arrival time of a ship.
https://localhost:44314/api/ship/nearestPort/{shipId}
eg: https://localhost:44314/api/ship/nearestPort/1
Expected result:
```
{
    "Name": "Harvey Deep Sea",
    "NearestPort": "Chefoo",
    "TimeToREach": "550 Min",
    "distance": "113 miles"
}
```









