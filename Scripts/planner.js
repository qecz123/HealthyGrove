$(".btn[btn='addPlants']").click(function () {
    var imgurl = $(this).attr('image');
    var spread = $(this).attr('spread');
    var img = document.createElement('img');
    img.src = imgurl;
    img.width = 100;
    img.height = 100;
    $("#plants").append(img)
})

$("#plants img").draggable({
    stack: "#dragged img",
    snap: true,
});

$('#planner img').draggable(
);

$('#planner').droppable({
    accept: "img",
});