import moment from 'moment'
import Cookies from 'universal-cookie'
import { CartApi, ShoppingCartDto } from '../api'

export async function getOrCreateCart(): Promise<string> {
    const api = new CartApi()
    const cookies = new Cookies()

    let cartId = cookies.get("cartId")
    if (!cartId || cartId === 'undefined') {
        let response = await api.apiCartCreateCartPost({});
        cartId = response
        cookies.set("cartId", cartId, { expires: moment().add(7, 'days').toDate() })
    }

    return cookies.get("cartId")
}