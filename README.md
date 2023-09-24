

1. Create a Vendor class. {name, description, List of Orders}
Create an Order class. This class should include properties for the title, the description, the price, the date, and any other properties you would like to include.
The homepage of the app at the root path (localhost:5000/) should be a splash page welcoming Pierre and providing him with a link to a Vendors page.
The vendors page should contain a link to a page presenting Pierre with a form he can fill out to create a new Vendor. After the form is submitted, the new Vendor object should be saved into a static List and Pierre should be routed back to the homepage.
Pierre should be able to click a Vendor's name and go to a new page that will display all of that Vendor's orders.
Pierre should be provided with a link to a page presenting him with a form to create a new Order for a particular Vendor. Hint: The route for this page might look something like: "/vendors/1/orders/new".