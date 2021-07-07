

var imageElement;
var people;
var id = null;
var windowBottom;
var windowRight;
var imageHeight;
var selectedNationality;
var totalScore = 0;

async function MovePictures(model) {
    totalScore = 0;
    $('#gameOver').hide();
    people = model;
    let peopleCount = model.length;
    for (let i = 0; i < peopleCount; i++) {
        doMove(people[i]);
        await sleep(3000);
    }
    $('#gameOver').show();
    totalScore -= peopleCount * 5;
    $('#Score').html("Score: " + totalScore);
}

function doMove(person) {
    imageElement.src = person.ImageUri;
    imageElement.seachKey = person.ImageUri;
    imageElement.offsetTop = 0;
    imageElement.style = "imageCenter";

    windowBottom = window.scrollY + window.innerHeight;
    imageHeight = $('#photo').height();

    var start = { x: 0, y: 0 };
    var end = { x: 0, y: 0 };
    start.x = $('#photo').position().left;
    start.y = imageHeight;
    end.x = start.x;
    end.y = windowBottom;
    moveObject(imageElement, 3000, start, end, false);
}

function moveObject(object, duration, start, end, fadeout) {
    var totalCount = 100;
    var count = 0;
    var xStep = (end.x - start.x) / totalCount;
    var yStep = (end.y - start.y) / totalCount;
    if (fadeout) {
        object.style.opacity = 1;
    }
    clearInterval(id);

    id = setInterval(frame, parseInt(duration / totalCount));
    function frame() {
        if (count < (totalCount - 1)) {
            count++;
            var top = object.style.top === "" ? 0 : parseFloat(object.style.top);
            object.style.top = top + yStep;
            if (end.x !== start.x) {
                var left = parseFloat(object.style.left);
                object.style.left = left + xStep;
            }
            if (fadeout) {
                object.style.opacity -= 1 / totalCount;
            }

        } else {
            clearInterval(id);
            count = 0;
        }
    }
}

function doDragDrop() {
    document.addEventListener('dragover', function (event) {
        event.preventDefault();
    });
    clearInterval(id);
    document.addEventListener("drop", function (event) {
        event.stopImmediatePropagation();
        if (event.stopPropagation) {
            event.stopPropagation();
        }
        event.preventDefault();
        var currentScore = calculateScore(event.clientX, event.clientY);
        totalScore += currentScore;
        console.log(totalScore);
        moveImageFadeout(event.clientX, event.clientY);
    });
}

function moveImageFadeout(x1, y1) {
    var start = { x: x1, y: y1 };
    var end = { x: 0, y: 0 };
    if (selectedNationality === "Thai") {
        end = { x: windowRight - imageHeight, y: windowBottom - imageHeight };
    }
    else if (selectedNationality === "Japanese") {
        end = { x: 0, y: 0 };
    }
    else if (selectedNationality === "Chinese") {
        end = { x: windowRight - imageHeight, y: 0 };
    }
    else if (selectedNationality === "Korean") {
        end = { x: 0, y: windowBottom - imageHeight };
    } else {
        alert("Something Went Wrong!!!");
    }

    imageElement.style = "imageReset";
    imageElement.style.left = x1 + 'px';
    imageElement.style.top = y1 + 'px';

    moveObject(imageElement, 1000, start, end, true);
}

function calculateScore(x, y) {
    windowRight = window.scrollX + window.innerWidth;
    selectedNationality = calculateNationality(x, y);
    var correctness = checkCorrectness(selectedNationality);
    if (correctness) {
        return 25;
    } else {
        return 0;
    }
}

function getCurrentPerson() {
    var imageUri = imageElement.seachKey;
    var person = people.find((person) => {
        return person.ImageUri === imageUri;
    });
    return person;
}

function checkCorrectness(selectedNationality) {
    if (selectedNationality === getCurrentPerson().Nationality) {
        return true;
    }
    return false;
}

function calculateNationality(x, y) {
    if (x > windowRight / 2 && y > windowBottom / 2) {
        return "Thai";
    } else if (x > windowRight / 2 && y <= windowBottom / 2) {
        return "Chinese";
    }
    else if (x <= windowRight / 2 && y <= windowBottom / 2) {
        return "Japanese";
    }
    else if (x <= windowRight / 2 && y > windowBottom / 2) {
        return "Korean";
    }
    return "Nothing";
}

function sleep(ms) {
    return new window.Promise(resolve => setTimeout(resolve, ms));
}
