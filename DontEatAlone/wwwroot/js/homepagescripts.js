// JavaScript Document

(function (d) {

    // d = document

    const $body = d.querySelector('body');
    const $btn = d.querySelector('.btn-menu');

    $btn.addEventListener('click', function () {

        $body.classList.toggle('show');

    });


})(document);


function relocate_facebook() {
    location.href = "https:\\www.facebook.com";
}

function relocate_instagram() {
    location.href = "https://www.instagram.com/icelandtravel/?hl=en";
}

function relocate_vimeo() {
    location.href = "https://vimeo.com/icelandinspired";

}

function relocate_flickr() {
    location.href = "https://www.flickr.com/groups/inspired_by_iceland/";
}

function relocate_twitter() {

    location.href = "https://twitter.com/hashtag/iceland?lang=en";
}
