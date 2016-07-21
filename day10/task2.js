<script>
  Array.prototype.each = function(callback) {
    this.forEach(function(item) {
      callback.call(item);
    });
  };
  
  this.forEach
  
  var a = [1, 2, 3];
  
  a.each(function() {
    console.log(this)
  });
  
</script>