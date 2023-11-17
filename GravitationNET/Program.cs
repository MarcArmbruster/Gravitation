// See https://aka.ms/new-console-template for more information

using GravitationNET;

ForceCalculator forceCalculator = new ForceCalculator();
double earthRadius = 6_371_000; // average value in meters
double mountEverest = 6_371_000 + 8_848;
double earthMass = 5.9722d * Math.Pow(10, 24);
double objectWeight = 1d; // 1kg

double force = forceCalculator.OutsideGravitationForce(earthMass, objectWeight, earthRadius);
Console.WriteLine($"The average force value of 1kg is: {force} N");

double everestForce = forceCalculator.OutsideGravitationForce(earthMass, objectWeight, mountEverest);
Console.WriteLine($"The force value on Mount Everst of 1kg is: {everestForce} N");

double insideForce = forceCalculator.InsideGravitationForce(earthMass, objectWeight, earthRadius, 5_371_000);
Console.WriteLine($"The force value of 1kg in depth of 1000m is: {insideForce} N");

Console.ReadLine();