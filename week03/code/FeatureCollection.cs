using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }  // Puede ser nulo, así que lo hacemos nullable
}