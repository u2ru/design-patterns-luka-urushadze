using Homework3.Task1_Visitor;
using Homework3.Task3_Observer;
using Homework3.Task2_Behavioral.Command;
using Homework3.Task2_Behavioral.Strategy;
using Homework3.Task2_Behavioral.TemplateMethod;

// Task 1 Demo
var visitor = new VolumeVisitor();
var shapes = new List<Shape> { new Sphere { Radius = 5 }, new Cube { Side = 10 } };
shapes.ForEach(s => s.Accept(visitor));

// task 2 demo
// Command Demo
ICommand print = new PrintCommand("Homework Report");
print.Execute();

// Strategy Demo
IRenderStrategy renderer = new VectorRender();
IRenderStrategy raster_renderer = new RasterRender();
renderer.Render("Company Logo");
raster_renderer.Render("Company Logo2 ");

// Template Method Demo
DataMiner miner = new PDFMiner();
miner.Mine("document.pdf");

// Task 3 Demo
var garage = new Container();
var myCar = new Sedan { Model = "A4" };

garage.Add(myCar);       // Logs addition
myCar.Model = "A6";     // Logs property change via Observer