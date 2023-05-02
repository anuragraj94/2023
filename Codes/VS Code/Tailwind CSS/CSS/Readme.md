# Hi, I'm Anurag! 👋


# Tailwind CSS

This readme file is for setup & install Tailwind CSS in your local system & create project with the help of Tailwind CSS Framework.
Reference document link:  https://tailwindcss.com/docs/installation

## Seup the Envirnment

Note: 
```bash
Check node is installed in your local system are not if not 
Then
Install node 
```
Download Node link : https://nodejs.org/en/download

## Folder Structure

```bash
Create two folders 
1. dist
2. src

```

## File Structure

```bash
1. Under src folder create a file
input.css
And add below libraries for tailwind css
@tailwind base;
@tailwind components;
@tailwind utilities;

2. Under dist folder create a file
index.html

```
## Command for initialize Tailwind CSS 
```bash
 npx tailwindcss init
```

## Setup CSS Path
```bash
 Open tailwind config file
 Add below path in content

 content: ["./dist/*.html"
```

## Command for build css file & run Tailwind watch
```bash
npx tailwindcss -i ./src/input.css -o ./dist/style.css --watch
```
## Link generated css file to html 
```bash
Link created css file to *.html
```
## Ignore vs code problems
```bash
 To ignore input.css files error open vs code
 Goto settings search for unknown and
 set 
 Lint:Unknown At Rules "ignore"
```

    
## Documentation

[Addional Documentation](https://linktodocumentation)


## Run Locally

Clone the project

```bash
  git clone https://link-to-project
```

Go to the project directory

```bash
  cd my-project
```

Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm run start
```


## 🛠 Skills
Javascript, HTML, CSS...


![Logo](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/th5xamgrr6se0x5ro4g6.png)


## FAQ

#### Question 1

Answer 1

#### Question 2

Answer 2


## License

[MIT](https://choosealicense.com/licenses/mit/)


