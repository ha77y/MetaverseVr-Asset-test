# MetaverseVr-Asset-test

## Water Shader

This water shader combines the sum for 4 different sine waves to produce a hieght offset. 
each wave takes in 5 variables and returns a float value. These 5 variables are : 1. Direction  2. Frequency  3. Amplitude  4. Speed  5.Size .
This shader relies on world space coordinates for 2 main reasons : It allows for uniformity over space ( no random seams between planes) and it also removes the need to find texture coordinates for buoyancy calulations.

>> The water Shader Has a debug mode that paints each channel with a different sine wave ( except red. red had two sinewaves).
>> It is a good way of visualising the changes you are making to the water mesh in real time. 
