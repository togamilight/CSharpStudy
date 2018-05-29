# Tip
* html中，单选框和文本最好用label标签包起来，这样点击文本可以选中该项
```
<label><input type="radio" name="name"> text</label>
<!--或者这样-->
<input type="radio" id="myRadio" name="name"> <label for="myRadio">text</label>
