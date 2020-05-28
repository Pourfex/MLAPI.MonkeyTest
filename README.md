# MLAPI.MonkeyTest
Some tests scenes to showcase how MLAPI handles lot of objects, data and so on...
Using MLAPI 11.11.2, Ruffles transport.

# How to Test 

Clone the project and duplicate it (you can use mklink or git..)

SampleScene is just to launch a Server or Client (no host here)

InteractionScene is where the test began

# Configuration :

Middle-level PC : Windows 10, gtx1070, 8gb Ram, SSD, intel I5 4 core -8 threads
High-End PC : Windows 10, gtx 2060, 16gb Ram, SSD, intel I7 8 cores - 16 Threads

# Tests

## 1st Test : 1000 simple objects owned by server, initial networked objects (don't use Object.Instantiate or NetworkedObject.Spawn but just an object in the editor with networked object)

Low-End  PC : Ok, no lag.
High-End PC : Ok, no lag.

## 2nd Test : 250 complex objects owned by server, initial networked objects (don't use Object.Instantiate or NetworkedObject.Spawn but just an object in the editor with networked object, networked transform, and a script with a networkedList with 115 Vector3)

Low-End PC : KO, lag + error + warning memory leak (both server and client)
High-End PC : OK, bit laggy, some warnings

## 3rd Test : 1000 complex objects owned by server, initial networked objects (don't use Object.Instantiate or NetworkedObject.Spawn but just an object in the editor with networked object, networked transform, and a script with a networkedList with 115 Vector3)

Low-End PC : KO
High-End PC : KO, lag + warning memory leak (both server and client)

# Others

Will commit the image of errors and warnings
