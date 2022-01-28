<script>
    export let seconds=30;
</script>

<div>
    <h1>{seconds} sec.</h1>
    <h2>Your turn</h2>
</div>

<style>
    div {
        width: max-content;
        margin-top: 0px;
        margin-left: 50%;
        transform: translateX(-50%);
    }

    h1 {
        font-family: "Roboto";
        font-style: normal;
        font-weight: 900;
        font-size: 64px;
        line-height: 48px;
        color: white;
    }
    h2 {
        margin-top: -0.5em;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 600;
        font-size: 42px;
        line-height: 48px;
        color: greenyellow;
    }
  
</style>
