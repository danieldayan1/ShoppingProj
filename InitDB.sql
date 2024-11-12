CREATE TABLE Category (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,  
    category_description NVARCHAR(255) NOT NULL    
);

CREATE TABLE Product (
    product_id INT PRIMARY KEY IDENTITY(1,1),   
    product_name NVARCHAR(255) NOT NULL,       
    category_id INT NOT NULL,             
    FOREIGN KEY (category_id) REFERENCES Category(Id) 
);

CREATE TABLE Chart (
    chart_id INT PRIMARY KEY IDENTITY(1,1),  
    buyer_name NVARCHAR(255) NOT NULL, 
	buyer_address NVARCHAR(255) NOT NULL,       
	buyer_mail NVARCHAR(255) NOT NULL,       
);

CREATE TABLE Chart_Products (
    list_id INT PRIMARY KEY IDENTITY(1,1),  
    chart_id INT NOT NULL,               
    product_id INT NOT NULL,             
    Quantity INT NOT NULL,              
    FOREIGN KEY (chart_id) REFERENCES Chart(chart_id),       
    FOREIGN KEY (product_id) REFERENCES Product(product_id) 
);

INSERT into Category(category_description) VALUES ('cleaning products');
INSERT into Category(category_description) VALUES ('Meat and fish');
INSERT into Category(category_description) VALUES ('dairy products');
INSERT into Category(category_description) VALUES ('vegetables and fruits');

INSERT into Product(product_name, category_id) VALUES ('Bleech', 1);
INSERT into Product(product_name, category_id) VALUES ('broom', 1);
INSERT into Product(product_name, category_id) VALUES ('bucket', 1);
INSERT into Product(product_name, category_id) VALUES ('soap', 1);
INSERT into Product(product_name, category_id) VALUES ('Apple', 4);
INSERT into Product(product_name, category_id) VALUES ('Yellow cheese', 3);
INSERT into Product(product_name, category_id) VALUES ('Yogurt', 3);
INSERT into Product(product_name, category_id) VALUES ('butter', 3);
INSERT into Product(product_name, category_id) VALUES ('Sausages', 2);
INSERT into Product(product_name, category_id) VALUES ('Salmon fish', 2);