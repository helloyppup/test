let price = Number(prompt('输入价格'))
let num = Number(prompt('输入数量'))
let total = price * num
let address = prompt('输入地址')
document.write(`
<h2>订单确认</h2>
    <table>
        <tr>
            <th>商品名称</th>
            <th>商品价格</th>
            <th>商品数量</th>
            <th>总价</th>
            <th>收货地址</th>
        </tr>
        <tr>
            <td>小米手机PLUS
            </td>
            <td>
                ${price}元
            </td>
            <td>
                ${num}
            </td>
            <td>
                ${total}元
            </td>
            <td>
                ${address}
            </td>
        </tr>
    </table>
`)