Reference document link: https://tailwindcss.com/docs/installation
Note: Check node is installed in your local system are not if not then install that First
create two folders 
dist, src
src => input.css (Note: Add 3 libraries in that file given below 
@tailwind base;
@tailwind components;
@tailwind utilities;  )
dist => index.html (all html recide here) 
Note: run command to initialize tailwind css "npx tailwindcss init" it will create your config file & add content path there "content: ["./dist/*.html"]," 
Note: Run command for create and run css file "npx tailwindcss -i ./src/input.css -o ./dist/style.css --watch" (It will build & run your css file)
Note: Link your created css file to *.html
Note: To ignore input.css files error open vs code settings search for unknown & set Lint:Unknown At Rules "ignore" 
