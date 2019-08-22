$(document).ready(function () {
    $("li.components").click(function () {
        var partname = $(this).attr('id');
        $("#componentcontent").load("ViewParts.aspx?part="+partname);
    });
    
});

function alertCart() {
    alert("Item was added to cart. Items will remain in cart for 60 minutes." );
}
/*
var componentsmenu = document.getElementById("componentsmenu");
function Alert() {
    console.log(this.id); 
    alert(this.id); 
}

console.log(componentsmenu);

for (i = 0; i <= componentsmenu.childElementCount - 1; i++) {
    componentsmenu.children[i].addEventListener("click", Alert); 
}
*/