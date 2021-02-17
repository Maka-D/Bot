$(document).ready(function () {

    $('#Submit').click(function () {      
        var userInput = $('[name=UsersQuestion]').val().trim();
        if (userInput == "") {
            $('#error').html("გთხოვთ შეიყვანოთ კითხვა!");
        }
        else {
            $.ajax({
                url: "/Home/UsersInputProcessing",
                method: "Post",
                data: { "UsersQuestion": userInput},
                success: function (response) {
                    if (response == "False") {
                        alert("გთხოვთ შეიყვანოთ კითხვა!");
                    }
                    else if (response == "Can't Find!") {
                       alert("სამწუხაროდ ამ კითხვაზე პასუხს ვერ გაგცემთ :(");
                    }
                    else {                      
                        $('#chatbox').append("<div dir='rtl'>" + userInput + "</div>");
                        $('#chatbox').append("<div>" + response + "</div>");
                    }
                    resetInput();
                },
                error: function () {
                    alert("Please contact system administrator!");

                }
            });
        }
        
       
       
    });

    $('#changeQ').click(function () {
        var qu  = $('[name=changedQ]').val().trim();
        var newQu = $('[name=newQ]').val().trim();
        if (qu == "" || newQu == "") {
            $('#editError').html("გთხოვთ შეიყვანოთ ორივე კითხვა!");
        }
        else {
            $.ajax({
                url: "/Home/Edit",
                method: "Post",
                data: { "Question": qu, "NewQuestion": newQu},
                success: function (response) {
                    if (response == "True") {
                        $('#editOk').html('წარმატებით განხორციელდა ცვლილება!');
                        resetQuestions();
                    } else {
                        $('#editError').html('ვერ მოხდა ცვლილებების განხორციელება!');
                    }

                },
                error: function () {
                    alert("Please contact system administrator!");

                }
            });
        }
    
    });
    $('#update').click(function () {
        var question = $('[name=question]').val().trim();
        var answer = $('[name=answer]').val().trim();
        if (answer == "" || question == "") {
            $('#editError').html('გთხოვთ შეავსოთ ყველა ველი!');
        }
       

    });
    $('#deleteQA').click(function () {
        var answer = $("[name=changedA]").val().trim();
        var question = $("[name=changedQ]").val().trim();
        if ( answer == "" || question == "") {
            $('#editError').html('გთხოვთ შეიყვანოთ კითხვაც და პასუხიც!');
        }
        else {
            $.ajax({
                url: "/Home/Edit",
                method: "Post",
                data: { "Answer": answer, "Question": question },
                success: function (response) {
                    if (response == "True") {
                        $('#editOk').html('წარმატებით განხორციელდა ცვლილება!');
                        resetAnswers();
                        resetQuestions();
                    } else {
                        $('#editError').html('ვერ მოხდა ცვლილებების განხორციელება!');
                    }
                   

                },
                error: function () {
                    alert("Please contact system administrator!");

                }
            });
        }

    });

    $('#addQA').click(function () {
        var question = $("[name=Question").val().trim();
        var answer = $("[name=Answer").val().trim();
        if (question == "" || answer == "") {
            $('#addError').html('შეავსეთ ორივე გრაფა!');
        } else {
            $('#addOk').html('წარმატებით დაემატა!');
        }

    });

    function resetInput() {
        $('[name=UsersQuestion]').val("");
    }
    function resetQuestions() {
        $('[name=changedQ]').val("");
        $('[name=newQ]').val("");
    }
    function resetAnswers() {
        $('[name=changedA]').val("");
        $('[name=newA]').val("");
    }
    
});