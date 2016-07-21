<script>
  
  function getRandomArbitrary(min, max) {
    return parseInt(Math.random() * (max - min) + min);
  }

  function reverseArrayInPlace(arr) {
    var key,
      arrLength = arr.length;
      
    for(var i = 0; i < arrLength / 2; i++) {
      key = arr[i];
      arr[i] = arr[arrLength - i - 1];
      arr[arrLength - i - 1] = key;
    }
  };
  
  function reverseArray(arr) {
    var newArr = [],
      arrLength = arr.length;
      
    for(var i = 0; i < arrLength; i++) {
      newArr[i] = arr[arrLength - 1 - i];
    }
    return newArr
  };
  
  var arr = [];
  var newArr = [];
  
  for(var i = 0; i < 10000; i++) {
      arr.push(getRandomArbitrary(0,100));
  }
  
  console.time("ReverseArray");
  newArr = reverseArray(arr);
  console.timeEnd("ReverseArray");

  console.time("ReverseArrayInPlace");
  reverseArrayInPlace(newArr);
  console.timeEnd("ReverseArrayInPlace");
  
</script>