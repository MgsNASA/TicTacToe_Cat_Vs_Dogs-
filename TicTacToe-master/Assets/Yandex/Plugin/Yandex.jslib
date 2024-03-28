var Yandex = {
    ShowAdv: function() {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    console.log("Advertisement closed");
                },
                onError: function(error) {
                    console.error("Error showing advertisement:", error);
                }
            }
        });
    }
};
mergeInto(LibraryManager.library, Yandex);
