using CSProject_API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<CSProject_API.Data.DBsettings>(builder.Configuration.GetSection("DBSettings"));
builder.Services.AddSingleton<customerservice>();
var app = builder.Build();

app.MapGet("/", () => "Customer API");

app.MapGet("api/customers", async (customerservice customerservice) => await customerservice.Get());

app.MapGet("api/customers/{id}",async(customerservice customerservice , string id) =>
{
    var customer = await customerservice.Get(id);
    return customer is null ? Results.NotFound() : Results.Ok(customer);
});

app.MapPut("api/customers/{id}", async (customerservice customerservice, string id, customer updatecustomer ) =>
{
    var customer = await customerservice.Get(id);
    if (customer is null) return Results.NotFound();


    updatecustomer.Id = customer.Id;
    await customerservice.Update(id, updatecustomer);

    return Results.Ok();
});

app.MapDelete("api/customers/{id}", async (customerservice customerservice, string id) =>
{
    var customer = await customerservice.Get(id);
    if (customer is null) return Results.NotFound();
    await customerservice.Remove(customer.Id);

    return Results.Ok();

   
});


app.MapPost("api/customers", async (customerservice customerservice, customer customer) =>
{
    await customerservice.Create(customer);
    return Results.Ok();
});
app.Run();
