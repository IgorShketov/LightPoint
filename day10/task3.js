<script>
  function Event () {
    this.subscribers = [];
  }
  
  Event.prototype.subscribe = function(subscriber, callBack) {
    subscriber._handleEvent = callBack;
    this.subscribers.push(subscriber);
  };
  
  Event.prototype.unsubscribe = function(subsriber) {
    this.subscribers = this.subscribers.filter(function(item) {
      if (item !== subsriber) {
        return item;
      }
    });
  }
  
  Event.prototype.notify = function(eventDescription){
    this.subscribers.forEach(function(item) {
      item._handleEvent(eventDescription);
    });
  }
  
  var event = new Event();
  var subscriber1 = {handler: function(msg) {console.log(msg)}};
  var subscriber2 = {differentHandler: function(msg) {alert(msg)}};
  
  event.subscribe(subscriber1, subscriber1.handler);
  event.subscribe(subscriber2, subscriber2.differentHandler);
  event.notify("Event happend");
  
</script>