import { Account } from "./Account.js"

export class Recipe {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.profile = data.profile
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.liked = data.liked || false
    this.favoriteId = data.favoriteId
  }
}