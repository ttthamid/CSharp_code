//============================================================
//============================================================
//============================================================
// Passing data without extending EventArgs
//============================================================
//============================================================
//============================================================

    
// The class that raises (or sends) the event is called the publisher.    
class Order
{
    public event EventHandler OnCreated;

    public void Create()
    {
        Console.WriteLine("Order created");
        
        // Raising an event
        if(OnCreated != null)
        {
            OnCreated(this, EventArgs.Empty);
        }
    }
}

// The classes that receive (or handle) the event are called subscribers. 
//  And the method of the classes that handle the event is often called event handlers.
class Email 
{
    // event handlers 
    public static void Send(object sender, EventArgs e)
    {
        Console.WriteLine($"Send an email");
    }
}

// The classes that receive (or handle) the event are called subscribers. 
//  And the method of the classes that handle the event is often called event handlers.
class SMS
{
    // event handlers 
    public static void Send(object sender, EventArgs e)
    {
        Console.WriteLine($"Send an SMS");
    }
}


class Program
{
    static void Main(string[] args)
    {
        var order = new Order();

        // add event handlers 
        order.OnCreated += Email.Send;
        order.OnCreated += SMS.Send;

        order.Create();
    }
}

#============================================================
#============================================================
#============================================================
# Passing data by extending EventArgs
#============================================================
#============================================================
#============================================================

class OrderEventArgs : EventArgs
{
    public string Email { get; set; }
    public string Phone { get; set; }
}

// The class that raises (or sends) the event is called the publisher.    
class Order
{
    public event EventHandler<OrderEventArgs> OnCreated;

    public void Create(string email, string phone)
    {
        Console.WriteLine("Order created");

        // Raising an event
        if(OnCreated != null)
        {
            OnCreated(this, new OrderEventArgs { Email = email, Phone = phone });
        }
    }
}


// The classes that receive (or handle) the event are called subscribers. 
//  And the method of the classes that handle the event is often called event handlers.
class Email 
{
    // event handlers 
    public static void Send(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"Send an email to {e.Email}");
    }
}

// The classes that receive (or handle) the event are called subscribers. 
//  And the method of the classes that handle the event is often called event handlers.
class SMS
{
    // event handlers 
    public static void Send(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"Send an SMS to {e.Phone}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var order = new Order();

        // add event handlers 
        order.OnCreated += Email.Send;
        order.OnCreated += SMS.Send;

        order.Create("john@test.com", "(408)-111-2222");
    }
}

