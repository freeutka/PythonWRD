<?php
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = htmlspecialchars($_POST['name']);
    $text = htmlspecialchars($_POST['text']);
    $size = htmlspecialchars($_POST['size']);
    $location = htmlspecialchars($_POST['location']);
    $code = htmlspecialchars($_POST['code']);

    $xmlFile = 'beta.xml';
    if (file_exists($xmlFile)) {
        $xml = simplexml_load_file($xmlFile);
    } else {
        $xml = new SimpleXMLElement('<Buttons></Buttons>');
    }

    $button = $xml->addChild('Button');
    $button->addChild('Name', $name);
    $button->addChild('Text', $text);
    $button->addChild('Size', $size);
    $button->addChild('Location', $location);
    $button->addChild('Code', $code);

    $xml->asXML($xmlFile);

    echo "<p>Кнопка успешно добавлена!</p>";
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Button</title>
</head>
<body>
    <h1>Add a New Button</h1>
    <form method="POST" action="">
        <label for="name">Button Name:</label><br>
        <input type="text" id="name" name="name" required><br><br>

        <label for="text">Button Text:</label><br>
        <input type="text" id="text" name="text" required><br><br>

        <label for="size">Button Size (e.g., 340,53):</label><br>
        <input type="text" id="size" name="size" required><br><br>

        <label for="location">Button Location (e.g., 1,76):</label><br>
        <input type="text" id="location" name="location" required><br><br>

        <label for="code">Button Code:</label><br>
        <textarea id="code" name="code" rows="10" cols="50" required></textarea><br><br>

        <button type="submit">Add Button</button>
    </form>
</body>
</html>
