<script>
    import Message from "./Message.svelte";
</script>

<div id="root">
    <h3>Chat:</h3>
    <a href="/">Hide</a>
    <hr />
    <div id="chatbox">
        <Message/>
        <Message/>
        <Message/>
        <Message/>
    </div>
</div>

<style>
    #root {
        margin-top: 2.5em;
        width: max-content;
    }

    h3 {
        margin-left: -74%;
        width: max-content;
        font-family: "Roboto";
        font-style: normal;
        font-weight: normal;
        font-size: 18px;
        line-height: 14px;
        color: red;
        display: inline;
    }

    a {
        margin-left: 1em;
    }

    hr {
        border: 0.1px solid black;
        width: 22em;
    }
    #chatbox {
        width: 22em;
        height: 40em;
        border: 1px solid black;
    }
</style>
