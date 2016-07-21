<script>
  function test() {
    var index = 0;
    arguments.myNext = _next;
    
    console.log(arguments.myNext());
    console.log(arguments.myNext());
    console.log(arguments.myNext());
    console.log(arguments.myNext());
    
    function _next() {
      return this[index++];
    }
  };
  
  test(1,2,3,4);
</script>