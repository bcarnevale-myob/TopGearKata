Top Gear Refactoring Kata
=========================

This is a refactoring challenge where we look at a production code base which needs a new feature. The code is in production and has been for at least 10 years.

The scenario is as follows
----------------------------

Modern cars are composed of mechanical systems many of which have their function automated electronically via software. This can include cruise control, fuel injection, dashboard speedometers, automatic breaking and collision detection systems.

The software module this kata address controls the automatic transmission, a crucial part of a cars operation. This software frees the driver from changing gears via a gearstick, instead it is able to detect when a change of gear is required and increase or decrease the gear as required. Nearly all cars for the last decade have an automatic transmission.

If a car is in the wrong gear it can cause tbe engine to stall or over exert the gearbox which can ruin the engine. Both of these events can be catastrophic while the car is in motion, therefore it is essential that it works flawlessly. The gear a car is in also has secondary consequences including fuel consumption and environmental impact via emissions.

Our team has been tasked with adding a new feature to the automatic transmission software of millions of cars currently in service via an automatic update.  
  
This task comes with it's share of challenges:
* The software is at least 10 years old and has never failed in this time
* It controls the automatic transmissions of millions of different model cars in operation around the world
* The engineers that initially wrote the software, not only aren't around anymore, no one remembers their names
* There is a legal requirement for these software changes to be rolled out due to new emission laws
* The code has been decompiled into c# and therefore has lost all semantics
* Has zero automated tests

What we do know:
* The module takes one input, an integer reading that comes from the software which controls engine components
* The module exposes two integer values which are read by an unknown number of systems, including one which performs the mechanical gear shifting
* We are free to rename and refactor the code as long as it's exposed methods and properties are exactly the same

What we have been told:
* Gear ranges of the transmission are fixed
* The gearbox always changes down at 500rpm (revolutions per minute of the engine)
* The gearbox always changes up at 2000rpm
* There are a fixed number of gears 

We can verify this basic information by asking any current driver of a car which has this software in use, but we don't have any more specifics on how it does this.

Requirements:
* Gear changes are now able to operate on a specific range. For example:
    * 1st -> 2nd: 2000rpm
    * 2nd -> 3rd: 2500rpm
    * 4th -> 3rd: 532rpm
* These ranges need to be individually configurable for different models, this configuration is already determined and will be provided to the module when it is initialised. We aren't required to read the configuration from anywhere. For example, another team could be tasked with deciding the ranges based on historical fuel consumption
* Stakeholders want us to guarantee that existing cars will continue to operate with 0% error as they have done for 10 years since initial release!
* Stakeholders want us to guarantee that the software will continue to operate with the new capability for another 10 years! 
