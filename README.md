# grocery-delivery-service (Work in Progress)

Architecture:

![image](https://user-images.githubusercontent.com/35512365/160915627-11f4ec95-5181-4184-a972-98800e55a289.png)

```mermaid
flowchart LR;
    request <----> products;
    request <----> categories;
    request <----> getOrders;
    request <----> submitOrder;
    products <----> database;
    categories <----> database;
    getOrders <----> database;
    submitOrder --> pendingOrdersTopic;
    pendingOrdersTopic --> kafkaconsumer;
    pendingOrdersTopic --> orderConfirmationConsumer;
    kafkaconsumer <----> pendingOrdersGrpc;
    pendingOrdersGrpc -->|Insert Pending Order| database;
    orderConfirmationConsumer --> request;
    database --> KafkaConnector;
    KafkaConnector --> deliveredOrdersTopic;

    database[(Database)];
    pendingOrdersTopic{Pending Orders Kafka Topic};
    deliveredOrdersTopic{Delivered Orders Kafka Topic};

    subgraph Angular Client;
    request;
    end;
    subgraph GroceryDeliveryAPI;
    products(GET: api/products);
    categories(GET: api/categories);
    getOrders(GET: api/orders);
    submitOrder(POST: api/orders);
    end;
    subgraph GroceryDeliveryConsumer;
    kafkaconsumer(kafka consumer);
    end;
    subgraph PendingOrdersService;
    pendingOrdersGrpc(Pending Orders gRPC Service);
    end;
    subgraph OrderConfirmationConsumer;
    orderConfirmationConsumer(Order Confirmation Kafka Consumer);
    end;
    subgraph KafkaConnector;
    end;
```
