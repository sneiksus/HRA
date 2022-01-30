<script>
export let roomDeck=0;

</script>

<div>
    <!-- <h3>turn 23</h3> -->
    <img src="./static/Deck.png" alt="deck">
    <p>{roomDeck} cards remains</p>
</div>

<style>
    div {
        width: max-content;
        margin-top: 5em;
    }

    h3 {
        font-family: "Roboto";
        font-style: normal;
        font-weight: 500;
        font-size: 36px;
        line-height: 48px;
        text-align: center;
        color: white;
    }
    img{
        margin-top: 0em;
        width: 70%;
        height: auto;
        margin-left: 50%;
        transform: translateX(-50%);
    }
    p{
        font-family: "Roboto";
        font-style: normal;
        font-weight: 500;
        font-size: 33px;
        line-height: 48px;
        text-align: center;
        margin-top: 0%;
        color: white;
    }
</style>
