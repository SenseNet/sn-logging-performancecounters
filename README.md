# Performance counters API for sensenet
Legacy API for managing Windows performance counters on the sensenet platform.

[![Performance counters API](https://img.shields.io/nuget/v/SenseNet.Logging.PerformanceCounters.svg)](https://www.nuget.org/packages/SenseNet.Logging.PerformanceCounters)

This package lets you register custom performance counters and access basic environment values (e.g. CPU usage and available RAM). 

> This is a legacy package for supporting older installations of sensenet. New projects should take a more modern approach. 
> 
> Please note that even if you install this package, the system does not manage the [built-in performance counters](http://wiki.sensenet.com/Performance_Counters), that feature has been removed. Custom performance counters and the necessary API for incrementing/decrementing them is still supported.