<script>
    export let nomarg=0;
</script>

<div class={!nomarg ? 'yemarg' : 'nomarg'}>
    <img src="https://www.pngkit.com/png/full/349-3495495_diamond-kys-white-diamond-icon-png.png" alt="logo"/>
    <h1>Атака</h1>
    <p>500</p>
</div>

<style>
    div {
        background-color: #40454b;
        height: 11em;
        width: 7em;
        border: 7px solid #ed4245;
        border-radius: 15px;
        transition: transform 0.2s ease-in-out;
        display: inline-block;
        text-align: center;
    }

    div:hover{
        transform: translateY(-1em);
        cursor: pointer;
    }

    img {
        width: 90%;
        margin-top: 1em;
    }

    h1 {
        margin-top: 1em;
        font-family: Roboto;
        font-style: normal;
        font-weight: normal;
        font-size: 1em;
        line-height: 14px;
        color: white;
    }

    p {
        font-family: 'Roboto';
        font-style: normal;
        font-weight: 500;
        font-size: 1em;
        line-height: 14px;
        color: white;
        margin-top: 0.6em;
    }

    .nomarg{
        margin-left: 0em;
    }
    .yemarg{
        margin-left: 2em;
    }
</style>
