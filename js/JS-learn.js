let num = []
for (let i = 0; i < 4; i++) {
    num.push(prompt(`输入第${i + 1}季度的数据`))
}

document.write(`
<div class="box">
`)
for (let i = 0; i < num.length; i++) {
    document.write(`
        <div style="height: ${num[i]}px;">
            <span> ${num[i]}</span>
            <h4>第${i + 1}季度</h4>
        </div>
    `)
}
document.write(`
</div>
`)